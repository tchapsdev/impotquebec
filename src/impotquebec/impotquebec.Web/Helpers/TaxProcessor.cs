using Tchaps.Impotquebec.Models;

namespace Tchaps.Impotquebec.Helpers
{
    public static class TaxProcessor
    {
        public static Declaration ProcessTp1Lines(this Declaration declaration)
        {
            #region Total income
            // Line 199 calculation: Total income. Add lines 101 and 105 through 164. 
            SetTaxLine(declaration, 199, GetSumLines(declaration,
                new float[] { 101, 105, 107, 110, 111, 114, 119, 122, 123, 128, 130, 136, 139, 142, 147, 148, 154, 164 }));
            #endregion

            #region Net income
            // Line 254 calculation: Total deductions. Add lines 201 through 207, 214 through 231, and 234 through 252. 
            SetTaxLine(declaration, 254, GetSumLines(declaration,
                new float[] { 201, 205, 207, 214, 225, 228, 231, 234, 236, 241, 245, 246, 248, 250, 252 }));

            // Line 256 calculation: Subtract line 254 from line 199.
            SetTaxLine(declaration, 256, GetSumLines(declaration, new float[] { 199 }) - GetSumLines(declaration, new float[] { 254 }));

            // Line 275 calculation: Net income. Add lines 256 and 260. 
            SetTaxLine(declaration, 275, GetSumLines(declaration,
                new float[] { 256, 260 }));
            #endregion

            #region Taxable income
            // Line 279 calculation: Add lines 275 through 278. 
            SetTaxLine(declaration, 279, GetSumLines(declaration,
                new float[] { 275, 276, 278 }));

            // Line 298 calculation: Add lines 287 through 297. Total deductions
            SetTaxLine(declaration, 398, GetSumLines(declaration,
                new float[] { 287,289, 290, 292, 293, 295, 297 }));

            // Line 299 calculation: Subtract line 298 from line 279. If the result is negative, enter 0. Taxable income
            var taxableImcome = GetSumLines(declaration, new float[] { 279 }) - GetSumLines(declaration, new float[] { 298 });
            SetTaxLine(declaration, 299, taxableImcome > 0 ? taxableImcome : 0);

            #endregion

            #region Non-refundable tax credits
            // Line 350 Basic personal amount 
            SetTaxLine(declaration, 350, 15728);

            // Line 359 calculation: Subtract line 358 from line 350.
            SetTaxLine(declaration, 398, GetSumLines(declaration, new float[] { 350 }) - GetSumLines(declaration, new float[] { 358 }));

            // Line 377 calculation: Add lines 359 through 376.
            SetTaxLine(declaration, 377, GetSumLines(declaration,
                new float[] { 359, 361, 367, 376}));

            // Line 377.1 calculation: Multiply line 377 by 15%.
            SetTaxLine(declaration, 377.1f, GetSumLines(declaration, new float[] { 377 }) * 0.15m);

            #endregion


            return declaration;
        }

        public static DeclarationDetail GetTaxLine( Declaration declaration, float lineNumber)
        {
            return declaration.Details.FirstOrDefault(d => d.LineNumber == lineNumber);
        }

        public static DeclarationDetail SetTaxLine( Declaration declaration, float lineNumber, decimal value)
        {
            return declaration.Details.FirstOrDefault(d => d.LineNumber == lineNumber);
        }

        public static decimal GetSumLines( Declaration declaration, float[] lineNumbers)
        {
            return declaration.Details.Where(d => lineNumbers.Contains(d.LineNumber) && !string.IsNullOrWhiteSpace(d.Value)).Sum(x => decimal.Parse(x.Value));
        }

    }
}
