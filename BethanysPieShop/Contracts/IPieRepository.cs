using BethanysPieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Contracts
{
    public interface IPieRepository
    {
        IEnumerable<Pie> GetAllPies();
        Pie GetPieById(int id);

        Pie AddPie(Pie pie);

        void UpdatePie(Pie pie);

        void Commit();
        void Delete(int id);
    }
}
