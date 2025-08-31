using System.Text;

namespace Leetcode.CodeGeneratorConsoleApp
{
    public class SolutionGenerator
    {
        private readonly string _csvPath;
        private readonly string _outputDir;

        public SolutionGenerator()
        {
            var baseDir = AppContext.BaseDirectory;

            // Input CSV in Input/program.csv
            _csvPath = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", "Input", "Problems.csv"));

            // Output folder: ../LeetcodeConsoleApp/Solutions
            _outputDir = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", "..", "LeetcodeConsoleApp", "Solutions"));
        }

        public void Run()
        {
            if (!File.Exists(_csvPath))
            {
                Console.WriteLine($"CSV file not found: {_csvPath}");
                return;
            }

            var lines = File.ReadAllLines(_csvPath);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(',', 3, StringSplitOptions.TrimEntries);
                if (parts.Length < 3) continue;

                var record = new ProblemDescription
                {
                    Name = parts[0],
                    Level = parts[1],
                    Signature = parts[2]
                };

                GenerateFile(record);
            }
        }

        private void GenerateFile(ProblemDescription record)
        {
            var parts = record.Name.Split('.', 2, StringSplitOptions.TrimEntries);
            var problemId = parts[0];
            var title = parts.Length > 1 ? parts[1] : record.Name;

            string className = ToClassName(title);
            string fileName = $"{problemId}_{ToFileName(title)}_{record.Level}.cs";
            string filePath = Path.Combine(_outputDir, fileName);

            string methodReturnType = record.Signature.Split(' ')[0];
            string methodName = record.Signature.Split(' ')[1].Split('(')[0];

            if (string.Equals(className, methodName, StringComparison.OrdinalIgnoreCase))
            {
                className += "Solution";
            }

            var parametersPart = record.Signature.Split('(')[1].TrimEnd(')');
            var parameters = parametersPart.Split(',', StringSplitOptions.RemoveEmptyEntries)
                                           .Select(p => p.Trim())
                                           .ToArray();

            string inputArray = GetInputArray(parameters);

            var sb = new StringBuilder();
            sb.AppendLine("namespace LeetcodeConsoleApp.Solutions");
            sb.AppendLine("{");
            sb.AppendLine($"    public class {className} : ISolution");
            sb.AppendLine("    {");
            sb.AppendLine("        public void Run()");
            sb.AppendLine("        {");
            sb.AppendLine($"            {inputArray}");
            sb.AppendLine("            foreach (var input in inputs)");
            sb.AppendLine("            {");

            if (parameters.Length == 1)
            {
                if (methodReturnType == "void")
                {
                    sb.AppendLine($"                {methodName}(input);");
                }
                else
                {
                    sb.AppendLine($"                var result = {methodName}(input);");
                    sb.AppendLine("                Console.WriteLine($\"Result {result}\");");
                }
            }
            else if (parameters.Length > 1)
            {
                sb.AppendLine("                // TODO: Adjust input unpacking for multiple parameters");
                if (methodReturnType == "void")
                    sb.AppendLine($"                {methodName}(/* input */);");
                else
                    sb.AppendLine($"                var result = {methodName}(/* input */);");
            }

            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine();
            sb.AppendLine($"        private static {record.Signature}");
            sb.AppendLine("        {");
            sb.AppendLine("            // TODO: Implement solution here");
            if (methodReturnType != "void")
                sb.AppendLine($"            return default({methodReturnType});");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            Directory.CreateDirectory(_outputDir);
            File.WriteAllText(filePath, sb.ToString());
            Console.WriteLine($"Generated {filePath}");
        }

        private string ToClassName(string title)
        {
            var words = title.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return string.Concat(words.Select(w => char.ToUpper(w[0]) + w.Substring(1)));
        }

        private string ToFileName(string title)
        {
            var words = title.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return string.Join("_", words.Select(w =>
                char.ToUpper(w[0]) + w.Substring(1).ToLower()));
        }

        private string GetInputArray(string[] parameters)
        {
            if (parameters.Length == 0)
                return "// No parameters for this method";

            // Currently only supports single-parameter input arrays correctly
            var paramType = parameters[0].Split(' ')[0];

            return paramType switch
            {
                "string" => "string[] inputs = [ \"leetcode\", \"ISolution\" ];",
                "int" => "int[] inputs = [ 0, 1, 42 ];",
                "int[]" => "int[][] inputs = [ [0, 1], [42] ];",
                "char[]" => "char[][] inputs = [ [\"abc\".ToCharArray()], [\"leetcode\".ToCharArray()] ];",
                _ => $"var inputs = /*add new input type in code generator*/"
            };
        }
    }
}
