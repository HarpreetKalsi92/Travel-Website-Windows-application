using System;

namespace ClassLibrary
{
    public class Package
    {
        /// <summary>
        /// Entity class created by Darren Uong
        /// Properties for class Package
        /// </summary>
        public int PackageId { get; set; }

        public string PkgName { get; set; }

        public DateTime? PkgStartDate { get; set; }

        public DateTime? PkgEndDate { get; set; }

        public string PkgDesc { get; set; }

        public decimal PkgBasePrice { get; set; }

        public decimal? PkgAgencyCommission { get; set; }

    }
}
