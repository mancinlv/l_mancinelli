using FlooringProgram.Models;

namespace FlooringProgram.BLL
{
    public class OrderCalculations
    {
        public  decimal CalculateTotalCost(decimal laborCost, decimal materialCost, decimal tax)
        {
            return laborCost + materialCost + tax;
        }

        public decimal CalculateTotalMaterialCost(decimal materialCostPerSquareFoot, decimal area)
        {
            return materialCostPerSquareFoot * area;
        }

        public decimal CalculateTotalLaborCost(decimal laborCostPerSquareFoot, decimal area)
        {
            return laborCostPerSquareFoot * area;
        }

        public decimal CalculateTotalTax(decimal taxRate, decimal totalMaterial, decimal totalLabor)
        {
            return taxRate*(totalLabor + totalMaterial);
        }

    }
}