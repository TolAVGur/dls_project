using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinesLayer;
using BusinesLayer.Repositories;
using PresentationLayer.Services;

namespace PresentationLayer
{
    public class ServicesManager
    {
        private DirectoriesService _dirService;
        private MaterialsService _matService;
        private DataManager _dataManager;

        public ServicesManager(DataManager dm)
        {
            _dataManager = dm;
            _dirService = new DirectoriesService(_dataManager);
            _matService = new MaterialsService(_dataManager);
        }

        public DirectoriesService DirService { get { return _dirService; } }
        public MaterialsService MatService { get { return _matService; } }
    }
}
