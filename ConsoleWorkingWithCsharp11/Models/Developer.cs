using System.Diagnostics.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWorkingWithCsharp11.Models
{
    internal class Developer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }

        [DeveloperParameter(nameof(assignment))]
        public void AssignWork(string assignment)
        {

        }

        [DeveloperParameter(nameof(T))]
        public void WorkMethod<T>()
        {

        }

        public void Urgent([DeveloperParameter(nameof(parameter))] int parameter)
        {

        }


    }

    internal class WorkItem 
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
    internal class DeveloperParameterAttribute : Attribute
    {
        public DeveloperParameterAttribute(string parameterName)
        {
            
        }
    }
}