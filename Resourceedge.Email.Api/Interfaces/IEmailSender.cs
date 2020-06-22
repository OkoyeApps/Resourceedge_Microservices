using Resourceedge.Email.Api.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Resourceedge.Email.Api.Interfaces
{
    public interface IEmailSender
    {
        Task<HttpStatusCode> SendToSingleEmployee(string Subject, SingleEmailDto singleEmail);
        Task<HttpStatusCode> SendMultipleEmail(string subject, string employeeName, EmailDtoForMultiple emailDtos, string message, string title);
        Task<string> FormatEmail(string Name, string supervisor, string message);
        Task<string> FormatEmail(string Name, string Url);
        Task<string> FormatEmailAppraisalScore(string Name, string score);
    }
}
