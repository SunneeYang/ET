using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using ET;

namespace ETTools
{
    internal class OpcodeInfo
    {
        public string Name;
        public uint Opcode;
    }

    public static class Program
    {
        
        private const string clientMessagePath = "../Unity/Assets/Model/Proto/";
        private const string serverMessagePath = "../Server/Model/Proto/";
        
        public static void Main()
        {
            string protoc = "";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                protoc = "protoc.exe";
            }
            else
            {
                protoc = "protoc";
            }
            
            // 遍历所有文件
            DirectoryInfo fdir = new DirectoryInfo(".");
            FileInfo[] file = fdir.GetFiles();
            if (file.Length != 0) //当前目录文件或文件夹不为空                   
            {
                foreach (FileInfo f in file) //显示当前目录所有文件   
                {
                    if (f.Extension.ToLower().Equals(".proto"))
                    {
                        string protoType = f.Name.Substring(0, 2);
                        string opcodeFileName = f.Name.Substring(0, f.Name.Length - 6) + "Opcode";

                        switch (protoType)
                        {
                            case "OM":
                                ProcessHelper.Run(protoc, $"--csharp_out=\"{clientMessagePath}\" --proto_path=\"./\" {f.Name}", waitExit: true);
                                OuterProto2CS.Proto2CS("ET", f.Name, clientMessagePath, opcodeFileName);
                                break;
                            
                            case "IM":
                                InnerProto2CS.Proto2CS("ET", f.Name, serverMessagePath, opcodeFileName);
                                break;
                            
                            default:
                                throw new FileLoadException("proto文件名必须以OM或者IM开头");
                        }
                    }
                }
            }

            Console.WriteLine("proto2cs succeed!");
        }

        public static class OuterProto2CS
        {
            private const string protoPath = "./";
            private static readonly char[] splitChars = { ' ', '\t' };
            private static readonly List<OpcodeInfo> msgOpcode = new List<OpcodeInfo>();

            public static void Proto2CS(string ns, string protoName, string outputPath, string opcodeClassName)
            {
                msgOpcode.Clear();
                string proto = Path.Combine(protoPath, protoName);

                string s = File.ReadAllText(proto);

                StringBuilder sb = new StringBuilder();
                //sb.Append("using ET;\n");
                sb.Append("\n");
                sb.Append($"namespace {ns}\n");
                sb.Append("{\n");

                bool isMsgStart = false;

                foreach (string line in s.Split('\n'))
                {
                    string newline = line.Trim();

                    if (newline == "")
                    {
                        continue;
                    }

                    if (newline.StartsWith("//"))
                    {
                        sb.Append($"{newline}\n");
                    }

                    if (newline.StartsWith("message"))
                    {
                        string parentClass = "";
                        isMsgStart = true;
                        string msgName = newline.Split(splitChars, StringSplitOptions.RemoveEmptyEntries)[1];
                        string[] ss = newline.Split(new[] { "//" }, StringSplitOptions.RemoveEmptyEntries);

                        if (ss.Length == 2)
                        {
                            parentClass = ss[1].Trim();
                        }
                        else
                        {
                            parentClass = "";
                        }

                        msgOpcode.Add(new OpcodeInfo() { Name = msgName, Opcode = msgName.Crc32Low() });

                        sb.Append($"\t[Message({opcodeClassName}.{msgName})]\n");
                        sb.Append($"\tpublic partial class {msgName} ");
                        if (parentClass != "")
                        {
                            sb.Append($": {parentClass} ");
                        }

                        sb.Append("{}\n\n");
                    }

                    if (isMsgStart && newline == "}")
                    {
                        isMsgStart = false;
                    }
                }

                sb.Append("}\n");

                GenerateOpcode(ns, opcodeClassName, outputPath, sb);
            }

            private static void GenerateOpcode(string ns, string outputFileName, string outputPath, StringBuilder sb)
            {
                sb.AppendLine($"namespace {ns}");
                sb.AppendLine("{");
                sb.AppendLine($"\tpublic static partial class {outputFileName}");
                sb.AppendLine("\t{");
                foreach (OpcodeInfo info in msgOpcode)
                {
                    sb.AppendLine($"\t\t public const uint {info.Name} = 0x{Convert.ToString(info.Opcode, 16)};");
                }

                sb.AppendLine("\t}");
                sb.AppendLine("}");

                string csPath = Path.Combine(outputPath, outputFileName + ".cs");
                File.WriteAllText(csPath, sb.ToString());
            }
        }

        
    }

    public static class InnerProto2CS
    {
        private const string protoPath = ".";
        private static readonly char[] splitChars = { ' ', '\t' };
        private static readonly List<OpcodeInfo> msgOpcode = new List<OpcodeInfo>();

        public static void Proto2CS(string ns, string protoName, string outputPath, string opcodeClassName)
        {
            msgOpcode.Clear();
            string proto = Path.Combine(protoPath, protoName);
            string csPath = Path.Combine(outputPath, Path.GetFileNameWithoutExtension(proto) + ".cs");

            string s = File.ReadAllText(proto);

            StringBuilder sb = new StringBuilder();
            sb.Append("using ET;\n");
            sb.Append("using System.Collections.Generic;\n");
            sb.Append($"namespace {ns}\n");
            sb.Append("{\n");

            bool isMsgStart = false;
            string parentClass = "";
            foreach (string line in s.Split('\n'))
            {
                string newline = line.Trim();

                if (newline == "")
                {
                    continue;
                }

                if (newline.StartsWith("//"))
                {
                    sb.Append($"{newline}\n");
                }

                if (newline.StartsWith("message"))
                {
                    parentClass = "";
                    isMsgStart = true;
                    string msgName = newline.Split(splitChars, StringSplitOptions.RemoveEmptyEntries)[1];
                    string[] ss = newline.Split(new[] { "//" }, StringSplitOptions.RemoveEmptyEntries);

                    if (ss.Length == 2)
                    {
                        parentClass = ss[1].Trim();
                    }

                    msgOpcode.Add(new OpcodeInfo() { Name = msgName, Opcode = msgName.Crc32Low() });

                    sb.Append($"\t[Message({opcodeClassName}.{msgName})]\n");
                    sb.Append($"\tpublic partial class {msgName}");
                    if (parentClass == "IActorMessage" || parentClass == "IActorRequest" || parentClass == "IActorResponse" ||
                        parentClass == "IFrameMessage")
                    {
                        sb.Append($": {parentClass}\n");
                    }
                    else if (parentClass != "")
                    {
                        sb.Append($": {parentClass}\n");
                    }
                    else
                    {
                        sb.Append("\n");
                    }

                    continue;
                }

                if (isMsgStart)
                {
                    if (newline == "{")
                    {
                        sb.Append("\t{\n");
                        continue;
                    }

                    if (newline == "}")
                    {
                        isMsgStart = false;
                        sb.Append("\t}\n\n");
                        continue;
                    }

                    if (newline.Trim().StartsWith("//"))
                    {
                        sb.AppendLine(newline);
                        continue;
                    }

                    if (newline.Trim() != "" && newline != "}")
                    {
                        if (newline.StartsWith("repeated"))
                        {
                            Repeated(sb, ns, newline);
                        }
                        else
                        {
                            Members(sb, newline, true);
                        }
                    }
                }
            }

            sb.Append("}\n");

            File.WriteAllText(csPath, sb.ToString());
            
            GenerateOpcode(ns, opcodeClassName, outputPath);
        }

        private static void GenerateOpcode(string ns, string outputFileName, string outputPath)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"namespace {ns}");
            sb.AppendLine("{");
            sb.AppendLine($"\tpublic static partial class {outputFileName}");
            sb.AppendLine("\t{");
            foreach (OpcodeInfo info in msgOpcode)
            {
                sb.AppendLine($"\t\t public const uint {info.Name} = 0x{Convert.ToString(info.Opcode, 16)};");
            }

            sb.AppendLine("\t}");
            sb.AppendLine("}");

            string csPath = Path.Combine(outputPath, outputFileName + ".cs");
            File.WriteAllText(csPath, sb.ToString());
        }

        private static void Repeated(StringBuilder sb, string ns, string newline)
        {
            try
            {
                int index = newline.IndexOf(";");
                newline = newline.Remove(index);
                string[] ss = newline.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
                string type = ss[1];
                type = ConvertType(type);
                string name = ss[2];

                sb.Append($"\t\tpublic List<{type}> {name} = new List<{type}>();\n\n");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{newline}\n {e}");
            }
        }

        private static string ConvertType(string type)
        {
            string typeCs = "";
            switch (type)
            {
                case "int16":
                    typeCs = "short";
                    break;
                case "int32":
                    typeCs = "int";
                    break;
                case "bytes":
                    typeCs = "byte[]";
                    break;
                case "uint32":
                    typeCs = "uint";
                    break;
                case "long":
                    typeCs = "long";
                    break;
                case "int64":
                    typeCs = "long";
                    break;
                case "uint64":
                    typeCs = "ulong";
                    break;
                case "uint16":
                    typeCs = "ushort";
                    break;
                default:
                    typeCs = type;
                    break;
            }

            return typeCs;
        }

        private static void Members(StringBuilder sb, string newline, bool isRequired)
        {
            try
            {
                int index = newline.IndexOf(";");
                newline = newline.Remove(index);
                string[] ss = newline.Split(splitChars, StringSplitOptions.RemoveEmptyEntries);
                string type = ss[0];
                string name = ss[1];
                string typeCs = ConvertType(type);

                sb.Append($"\t\tpublic {typeCs} {name} {{ get; set; }}\n\n");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{newline}\n {e}");
            }
        }
    }
}
