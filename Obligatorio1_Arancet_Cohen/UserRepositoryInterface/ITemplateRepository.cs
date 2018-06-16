using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Domain;

namespace DomainRepositoryInterface
{
    public interface ITemplateRepository
    {
        Template GetTemplateByName(string name); 

    }
}
