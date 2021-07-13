using System;
using System.Collections.Generic;
using StoreAppModels;
using StoreAppDL;

namespace StoreAppBL {
    public class StoreFrontBL : IStoreFrontBL {
        private IRepository _repository;
        public StoreFrontBL(IRepository p_repository) {
            _repository = p_repository;
        }
        public List<LineItem> SearchStore(string _storeName) {
            return _repository.SearchStore(_storeName);
        }
    }
}