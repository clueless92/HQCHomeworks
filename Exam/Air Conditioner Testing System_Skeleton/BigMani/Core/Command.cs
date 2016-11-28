namespace ACTS.Core
{
    using System;
    using ACTS.Utils;

    public class Command
    {
        public Command(string line)
        {
            try
            {
                int nameSubstringEndIndex = line.IndexOf(' ');
                int parametersSubstringStartIndex = nameSubstringEndIndex + 1;

                this.Name = line.Substring(0, nameSubstringEndIndex);
                //// BUG: paremeters were not split successfully; FIX: added +1 to substring index
                this.Parameters = line.Substring(parametersSubstringStartIndex)
                    .Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Constants.InvalidCommand, ex);
            }
        }

        public string Name { get; private set; }

        public string[] Parameters { get; private set; }
    }
}
