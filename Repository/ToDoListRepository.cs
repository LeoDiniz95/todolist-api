using todolist_api.Data;
using todolist_api.General;
using todolist_api.Models;

namespace todolist_api.Repository
{
    public class ToDoListRepository
    {
        private DataContext _context { get; }
        public ToDoListRepository(DataContext context)
        {
            _context = context;
        }

        public GeneralResult GetAll()
        {
            var result = new GeneralResult();

            try
            {
                result.data = _context.ToDoListDMs?.Where(x => x.status == Constants.Status.active);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }


            return result;
        }

        public ToDoListDM Get(int id) => _context.ToDoListDMs?.SingleOrDefault(x => x.id == id);

        public GeneralResult Save(ToDoListDM item)
        {
            var result = new GeneralResult();

            try
            {
                if (item.id > 0)
                    _context.ToDoListDMs.Update(item);
                else
                    _context.ToDoListDMs.Add(item);

                _context.SaveChanges();

                result.data = item;
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        public GeneralResult Add(string name)
        {
            var result = new GeneralResult();
            var item = new ToDoListDM();

            try
            {
                item.name = name;
                item.done = Constants.Done.notdone;
                item.status = Constants.Status.active;
                result = Save(item);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        public GeneralResult ChangeStatus(int id)
        {
            var result = new GeneralResult();
            ToDoListDM item = null;

            try
            {
                item = Get(id);

                if (item != null)
                {
                    item.done = item.done == Constants.Done.done ? Constants.Done.notdone : Constants.Done.done;
                    result = Save(item);
                }
                else
                    result.AddError(Messages.Errors.generic);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        public GeneralResult Delete(int id)
        {
            var result = new GeneralResult();
            ToDoListDM item = null;

            try
            {
                item = Get(id);

                if (item != null)
                {
                    item.status = Constants.Status.inactive;
                    result = Save(item);
                }
                else
                    result.AddError(Messages.Errors.generic);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }
    }
}
