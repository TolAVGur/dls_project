using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinesLayer.Interfaces;

namespace BusinesLayer.Repositories
{
    public class DataManager 
    {
        private IDirectoriesRepository _dirRepos;
        private IMaterialsRepository _matRepos;

        public DataManager(IDirectoriesRepository dirRepos, IMaterialsRepository matRepos)
        {
            _dirRepos = dirRepos;
            _matRepos = matRepos;
        }

        public IDirectoriesRepository DirRepos { get { return _dirRepos; } }
        public IMaterialsRepository MatRepos { get { return _matRepos; } }
    }
}
