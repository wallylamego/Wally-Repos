using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp
{
    public class VehicleBusinessLayer
    {
        public int FindAllocationSplitID(int ? CostCentreID)
        {
            int AllocationSplitID = 1; //Country By Principal

            switch (CostCentreID)
            {
                case 1: //Bat
                    AllocationSplitID = 9;
                    break;
                case 2: //Liquor
                    AllocationSplitID = 6;
                    break;
                case 3: //FMCG
                    AllocationSplitID = 8;
                    break;
                case 6: //ALL
                    AllocationSplitID = 5;
                    break;
                case 7: //FMCG
                    AllocationSplitID = 7;
                    break;
                case 8: //SIMBA
                    AllocationSplitID = 10;
                    break;
                case 9: //NESTLE
                    AllocationSplitID = 11;
                    break;
                case 10: //DELIVERY
                    AllocationSplitID = 5;
                    break;
                case 11: //DELIVERY
                    AllocationSplitID = 5;
                    break;
                default:
                    AllocationSplitID = 1;
                    break;

            }
            
            return AllocationSplitID;
        }
    }
}
