using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepassCopyTool.Application.Validators
{
    public class ValidationResult
    {
        private List<string> _errors { get; set; }

        public ValidationResult()
        {
            _errors = new List<string>();
        }

        public bool IsValid() => !_errors.Any();

        public void AddError(string error) => _errors?.Add(error);

        public List<string> Errors => _errors.ToList(); 

    }
}
