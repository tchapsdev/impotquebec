using Tchaps.Impotquebec.Models;

namespace Tchaps.Impotquebec.Helpers
{
    public static class TaxProcessor
    {
        public static Declaration ProcessTp1Lines(this Declaration declaration)
        {
            #region Total income
            // Line 199 calculation: Total income. Add lines 101 and 105 through 164. 
            declaration.SetTaxLine( 199, declaration.GetSumLines(
                new float[] { 101, 105, 107, 110, 111, 114, 119, 122, 123, 128, 130, 136, 139, 142, 147, 148, 154, 164 }));
            #endregion

            #region Net income
            // Line 254 calculation: Total deductions. Add lines 201 through 207, 214 through 231, and 234 through 252. 
            declaration.SetTaxLine(254, declaration.GetSumLines(
                new float[] { 201, 205, 207, 214, 225, 228, 231, 234, 236, 241, 245, 246, 248, 250, 252 }));

            // Line 256 calculation: Subtract line 254 from line 199.
            declaration.SetTaxLine(256, declaration.GetDiffLines(199, 254));

            // Line 275 calculation: Net income. Add lines 256 and 260. 
            declaration.SetTaxLine(275, declaration.GetSumLines( new float[] { 256, 260 }));
            #endregion

            #region Taxable income
            // Line 279 calculation: Add lines 275 through 278. 
            declaration.SetTaxLine(279, declaration.GetSumLines(
                new float[] { 275, 276, 278 }));

            // Line 298 calculation: Add lines 287 through 297. Total deductions
            declaration.SetTaxLine(398, declaration.GetSumLines(
                new float[] { 287,289, 290, 292, 293, 295, 297 }));

            // Line 299 calculation: Subtract line 298 from line 279. If the result is negative, enter 0. Taxable income
            var taxableImcome = declaration.GetDiffLines(279, 298);
            declaration.SetTaxLine(299, taxableImcome > 0 ? taxableImcome : 0);

            #endregion

            #region Non-refundable tax credits
            // Line 350 Basic personal amount 
            declaration.SetTaxLine(350, 15728);

            // Line 359 calculation: Subtract line 358 from line 350.
            declaration.SetTaxLine(398, declaration.GetDiffLines(350, 358));

            // Line 377 calculation: Add lines 359 through 376.
            declaration.SetTaxLine(377, declaration.GetSumLines(
                new float[] { 359, 361, 367, 376}));

            // Line 377.1 calculation: Multiply line 377 by 15%.
            declaration.SetTaxLine(377.1f, declaration.GetValueFromLine(377) * 0.15m);

            // Line 388 calculation: Add lines 378 through 385.
            declaration.SetTaxLine(388, declaration.GetSumLines(
                new float[] { 378, 381, 385 }));

            // Line 389 calculation: A Multiply line 388 by 20%.
            declaration.SetTaxLine(377, declaration.GetValueFromLine(388) * 0.2m);

            // Line 399 calculation: Add lines 377.1, 389 through 392, 395 through 397, 398 and 398.1. Non-refundable tax credits
            declaration.SetTaxLine(377, declaration.GetSumLines(
                new float[] { 389, 390, 391, 392, 395, 396, 397, 398, 398.1f }));
            #endregion

            #region Income tax and contributions
            // Line 406 calculation: Non-refundable tax credits (line 399)
            declaration.SetTaxLine(406, declaration.GetValueFromLine(399));

            // Line 413 calculation: Subtract line 406 from line 401. If you must complete Part A of Schedule E, enter the amount from line 413 
            declaration.SetTaxLine(413, declaration.GetDiffLines(350, 358));

            // Line 425 calculation: Add lines 414 through 424.
            declaration.SetTaxLine(425, declaration.GetSumLines(
                new float[] { 414, 415, 422, 424 }));

            // Line 430 calculation: Subtract line 425 from line 413. If the result is negative, see line 431 in the guide.3 
            declaration.SetTaxLine(430, declaration.GetValueFromLine(413) - declaration.GetValueFromLine(425));

            // Line 432 calculation: Subtract line 431 from line 430, or enter the amount from line 18 in Part B of Schedule E.
            // If the result is negative, enter 0. Carry the result to page 4. 
            var l432 = declaration.GetDiffLines(430, 431);
            declaration.SetTaxLine(432, l432 > 0 ? l432 : 0);

            // Line 450 calculation: Add lines 432 through 447.  Income tax and contributions
            declaration.SetTaxLine(450, declaration.GetSumLines(
                new float[] { 432, 438, 439, 441, 443, 445, 446, 447 }));

            #endregion


            return declaration;
        }

    }
}
