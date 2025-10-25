using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradProj.Application.ServiceAbs
{
    public interface ISender
    {
        Task SendMailkitAsync(string to, string subject, string body);
    }
}
