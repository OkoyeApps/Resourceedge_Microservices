using Resourceedge.Appraisal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resourceedge.Appraisal.API.Helpers
{
    public static class KeyResultAreaExtension
    {

        public static KeyResultArea SetActive(this KeyResultArea resultArea)
        {
            if ((resultArea.Status.Hod.HasValue && resultArea.Status.Hod.Value) && (resultArea.Status.Employee.HasValue && resultArea.Status.Employee.Value) && (resultArea.Status.IsAccepted.HasValue && resultArea.Status.IsAccepted.Value))
            {
                resultArea.IsActive = true;
                resultArea.Approved = true;
            }
            //else
            //{
            //    resultArea.IsActive = false;
            //    resultArea.Approved = false;
            //}

            return resultArea;
        }
    }
}
