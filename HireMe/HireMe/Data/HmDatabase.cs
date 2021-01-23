using System;
using System.Collections.Generic;
using System.Text;

namespace HireMe.Data
{
    using SQLite;
    using Models;
    using ViewModel;
    using System.Threading.Tasks;
    using System.Linq;

    public class HmDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public HmDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<UsersHm>().Wait();
            _database.CreateTableAsync<UsersWorkers>().Wait();
            _database.CreateTableAsync<RegistroBusqueda>().Wait();
            _database.CreateTableAsync<PostUsers>().Wait();

        }

        public Task<int> SaveUser(UsersHm user)
        {
            if(user.Id_userhm != 0)
            {
                return _database.UpdateAsync(user);
            }
            else
            {
                return _database.InsertAsync(user);
            }
        }
        //Metodo para obtener ID de un usurio registrado, para registrar en la tabla de worker el usuario registrado con su profesion
        int b = 0;
        public int getUserId(String mail)
        {

            var e = _database.QueryAsync<UsersHm>("Select Id_userhm from UsersHm where Mail_user = ?", mail).Result;
            b =  e.Select(i => i.Id_userhm).First();
            return  b;
        }

        //metodo para obtener los datos de un usurio
        public Task<UsersHm> getUserHm(string mailUser)
        {
            return _database.Table<UsersHm>()
                .Where(i => i.Mail_user == mailUser)
                .FirstOrDefaultAsync();
        }
        
        public Task<int> SaveUserWorker(UsersWorkers userWorker)
        {
            if (userWorker.IdUserWork != 0)
            {
                return _database.UpdateAsync(userWorker);
            }
            else
            {
                return _database.InsertAsync(userWorker);
            }
        }
        // obtener toda la data de los usuarios registrados
        public Task<List<UsersHm>> GetUsersHM()
        {
            return _database.Table<UsersHm>().ToListAsync();
        }

        /*metodo preparado para consultar los usuarios que poseen una profesion, 
        TODAVIA ya HA SIDO TESTEADO
        por el momento funciona, pero obviamente pueden ocurrir exepciones que no han sido validadas*/
        
        public List<SearchItemViewModel> GetUsersWorkers()
        {
            List<SearchItemViewModel> list;
            list = _database.QueryAsync<SearchItemViewModel>("Select UsersHm.Nombre_c, UsersHm.Apellido_user, UsersHm.Mail_user, UsersHm.Celular, UsersHm.Ubicacion, UsersWorkers.profesion " +
                "from UsersHm, UsersWorkers " +
                "Where UsersHm.Id_userhm = UsersWorkers.Id_userhm").Result;
            /*List<UsersWorkerModel> result = list.Result;*/
            return list;
        }

        public Task<UsersWorkers> GetUserWorker(int id_user)
        {
            return _database.Table<UsersWorkers>()
                .Where(w => w.Id_userhm == id_user)
                .FirstOrDefaultAsync();
        }

        public List<SearchItemViewModel> GetUsersWorkersFilter(string filter)
        {
            List<SearchItemViewModel> filterList;
            filterList = _database.QueryAsync<SearchItemViewModel>("Select UsersHm.Nombre_c, UsersHm.Apellido_user, UsersHm.Mail_user, UsersHm.Celular, UsersHm.Ubicacion, UsersWorkers.profesion " +
                "from UsersHm, UsersWorkers " +
                "Where UsersHm.Id_userhm = UsersWorkers.Id_userhm and UsersWorkers.profesion like '%" + filter + "%'").Result;
            return filterList;
        }
        
        public Task<int> BorrarDataDB()
        {
            /*var objetosUW = _database.DeleteAllAsync<UsersWorkers>();
            Console.WriteLine(objetosUW.Result + "fueron borrados de la tabla UW");
            var objetosUH = _database.DeleteAllAsync<UsersHm>();
            Console.WriteLine(objetosUH.Result + "fueron borrados de la tabla HM");*/
            var objetosPost = _database.DeleteAllAsync<PostUsers>();
            Console.WriteLine(objetosPost.Result + "fueron borrados de la tabla PostUsers");
            
            return objetosPost;   
        }

        public int ConsultaLogin(string Mail, string Passw)
        {
            List<UsersHm> consultaUser;
            consultaUser = _database.QueryAsync<UsersHm>("Select Mail_user, Password_user from UsersHm where Mail_user = ? and Password_user = ?", Mail, Passw).Result;
            if (consultaUser.Count > 1)
            {
                return consultaUser.Count;
            }
            else
            {
                return consultaUser.Count;
            }
            
        }

        //Metodos de publicaciones
        public Task<int> SavePostUser(PostUsers post)
        {
            if (post.IdPost != 0)
            {
                return _database.UpdateAsync(post);
            }
            else
            {
                return _database.InsertAsync(post);
            }
        }

        public Task<List<PostUsers>> GetPosts()
        {
            return _database.Table<PostUsers>().ToListAsync();
        }
    }
}
