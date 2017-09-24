namespace _01HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class CommandInterpreter
    {
        private StringBuilder sb;
        private string result;

        public CommandInterpreter()
        {
            this.sb = new StringBuilder();
            this.result = "";
        }

        public string TakeFields(string typeOfField)
        {
            var classType = Type.GetType("_01HarvestingFields.HarvestingFields");
            var privateFields = classType.GetFields(BindingFlags.Instance 
                | BindingFlags.NonPublic 
                | BindingFlags.Public 
                | BindingFlags.Static);

            switch (typeOfField)
            {
                case "private":
                    foreach (var field in privateFields.Where(f => f.IsPrivate))
                    {
                        sb.AppendLine($"{typeOfField} {field.FieldType.Name} {field.Name}");
                    }
                    this.result = this.sb.ToString().Trim();
                    this.sb.Clear();

                    return this.result;

                case "protected":
                    foreach (var field in privateFields.Where(f => f.IsFamily))
                    {
                        sb.AppendLine($"{typeOfField} {field.FieldType.Name} {field.Name}");
                    }
                    this.result = this.sb.ToString().Trim();
                    this.sb.Clear();

                    return this.result;

                case "public":
                    foreach (var field in privateFields.Where(f => f.IsPublic))
                    {
                        sb.AppendLine($"{typeOfField} {field.FieldType.Name} {field.Name}");
                    }
                    this.result = this.sb.ToString().Trim();
                    this.sb.Clear();

                    return this.result;

                case "all":
                    foreach (var field in privateFields)
                    {
                        var fieldType = field.Attributes.ToString().ToLower();
                        if (fieldType == "family")
                        {
                            fieldType = "protected";
                        }
                        sb.AppendLine($"{fieldType} {field.FieldType.Name} {field.Name}");
                    }
                    this.result = this.sb.ToString().Trim();
                    this.sb.Clear();

                    return this.result;

                default:
                    return "This command is not valid!";
            }
        }
    }
}
