using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utils.Comandos
{
    public class CommandResultPadrao : ICommandResult
    {
        private List<String> errors;

        public bool OK
        {
            get;
            private set;
        }

        public IEnumerable<string> Errors
        {
            get { return this.errors; }
        }

        public CommandResultPadrao()
        {
            this.errors = new List<String>();
            this.OK = true;
        }

        private CommandResultPadrao(params String[] errors)
        {
            this.errors = new List<String>(errors);
            this.OK = this.errors.Count == 0;
        }

        public CommandResultPadrao Error(String msg)
        {
            this.errors.Add(msg);
            this.OK = false;

            return this;
        }

        public CommandResultPadrao Reset()
        {
            this.errors.Clear();
            this.OK = true;

            return this;
        }

        public static ICommandResult Success()
        {
            return new CommandResultPadrao();
        }

        public static ICommandResult FromError(String msg)
        {
            return new CommandResultPadrao(msg);
        }
    }
}
