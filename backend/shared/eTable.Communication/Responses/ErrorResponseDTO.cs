using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTable.Communication.Responses
{
    public class ErrorResponseDTO
    {
        // TIP: Construtor de uma única linha
        public ErrorResponseDTO(IList<string> errors) => Errors = errors;
        public ErrorResponseDTO(string error)
        {
            Errors = [error];
        }
        public IList<string> Errors { get; set; }
    }
}
