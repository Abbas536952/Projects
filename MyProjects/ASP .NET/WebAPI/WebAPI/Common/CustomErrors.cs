using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Common
{
    public enum CustomErrors
    {
        #region Band

        [Description("Band not found.")]
        BandNotFound = 100,

        [Description("Band already exists.")]
        BandAlreadyExists = 110,

        #endregion

        #region Album

        [Description("Album not found.")]
        AlbumNotFound = 200,

        [Description("Album already exists.")]
        AlbumAlreadyExists = 210,

        #endregion

    }
}
