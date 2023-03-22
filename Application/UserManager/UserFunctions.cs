using Application.Core;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Domain;

namespace Application.UserManager
{
    public class UserFunctions
    {
        public async static Task<Result<bool>> UpdateUser(DataContext _context, 
            string GrpId, 
            ICollection<string> users ){

                ICollection<UserType> userList =  new List<UserType>();

                foreach(string usr in users){
                    UserType user = new UserType();
                    if(usr.StartsWith("U:")){
                        user.Type = "U";
                    }
                    else if(usr.StartsWith("G:")){
                        user.Type = "G";                     
                    }

                    user.UserId = usr.Remove(0,2);
                    user.GrpId = GrpId;
                    userList.Add(user);
                }                                

                var items = await _context.UserTypes     
                    .Where(c => c.GrpId == GrpId )
                    .ToListAsync();

            //Remove if not exists
            ICollection<UserType> remList = new List<UserType>();
            foreach( UserType itm in  items ){
                bool remove = true;
                foreach( UserType nIt in userList ){
                    if( itm.Type == nIt.Type && itm.UserId == nIt.UserId ){
                        remove = false;
                    }
                }
                if(remove){
                    remList.Add(itm);			
                }                    
            }                    
            foreach( UserType ass in  remList ){
                _context.UserTypes.Remove(ass);
	        }

            //Add New items
            ICollection<UserType> addList = new List<UserType>();
            
            foreach( UserType nIt in  userList ){
                bool add = true;
                foreach( UserType itm in  items ){
                    if( itm.Type == nIt.Type && itm.UserId == nIt.UserId ){
                        add = false;
                    }
                }
                if(add){
                    addList.Add(nIt);                                  
                }         
            }
            
            foreach( UserType aIt in  addList ){
                _context.UserTypes.Add(aIt);
            }
            
            //SaveChangesAsync
            var result = await _context.SaveChangesAsync() > 0;


            return Result<bool>.Success(true);

        }
    }
}