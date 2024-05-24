using imtahan.Core.Models;
using imtahan.Core.RepositoryAbstracts;
using imtahan.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imtahan.Data.RepositoryConcretes
{
    public class SpeakerRepository : GenericRepository<Speaker>, ISpeakerRepository
    {
        public SpeakerRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }


    }
}
