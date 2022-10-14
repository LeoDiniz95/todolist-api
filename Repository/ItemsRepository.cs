using todolist_api.Data;
using todolist_api.General;
using todolist_api.Models;

namespace todolist_api.Repository
{
    public class ItemsRepository
    {
        private DataContext _context { get; }
        public ItemsRepository(DataContext context)
        {
            _context = context;
        }

        public GeneralResult GetAll()
        {
            var result = new GeneralResult();

            try
            {
                result.data = _context.ItemDMs?.Where(x => x.status == Constants.Status.active);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }


            return result;
        }

        public ItemDM Get(int id) => _context.ItemDMs?.SingleOrDefault(x => x.id == id);

        public GeneralResult Save(ItemDM item)
        {
            var result = new GeneralResult();

            try
            {
                if (item.id > 0)
                    _context.ItemDMs.Update(item);
                else
                    _context.ItemDMs.Add(item);

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
            var item = new ItemDM();

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
            ItemDM item = null;

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
            ItemDM item = null;

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
