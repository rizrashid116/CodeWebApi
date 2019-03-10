using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWebApi.Services
{
    public class SpyService
    {
        public bool FindSpy(string codeName, string message)
        {
            try
            {
                List<int> MessageIds = message.Split(',').Select(int.Parse).ToList();
                List<int> CodeIds = codeName.Split(',').Select(int.Parse).ToList();

                int i = 0;
                int j = 0;
                int index = 0;
                for (i = 0; i < CodeIds.Count; i++)
                {
                    for (j = 0; j < MessageIds.Count; j++)
                        if (CodeIds[i] == MessageIds[j] && j >= index)
                        {
                            index = j;
                            break;
                        }

                    if (j == MessageIds.Count)
                        return false;
                }

                return true;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}