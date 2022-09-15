using CustomerManagement.BusinessEntities;
using CustomerManagement.Interfaces;
using System;
using System.Web.Mvc;

namespace CustomerRepo.WebMVC.Tests
{
    public class NotesController
    {
        public NotesController()
        {
        }

        public NotesController(IRepository<Notes> @object)
        {
            Object = @object;
        }

        public IRepository<Notes> Object { get; }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public RedirectToRouteResult Create(Notes notes)
        {
            throw new NotImplementedException();
        }

        public void Delete(int v)
        {
            throw new NotImplementedException();
        }

        public RedirectToRouteResult Delete(Notes notes)
        {
            throw new NotImplementedException();
        }

        public void Edit(int v)
        {
            throw new NotImplementedException();
        }

        public RedirectToRouteResult Edit(int v, Notes notes)
        {
            throw new NotImplementedException();
        }

        public object Index()
        {
            throw new NotImplementedException();
        }
    }
}