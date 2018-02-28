﻿#region Greenshot GNU General Public License

// Greenshot - a free and open source screenshot tool
// Copyright (C) 2007-2018 Thomas Braun, Jens Klingen, Robin Krom
// 
// For more information see: http://getgreenshot.org/
// The Greenshot project is hosted on GitHub https://github.com/greenshot/greenshot
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 1 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

#endregion

#region Usings

using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using GreenshotPlugin.Core.Enums;
using Dapplo.Ini;
using Dapplo.Ini.Converters;

#endregion

namespace GreenshotBoxPlugin
{
	/// <summary>
	///     Description of ImgurConfiguration.
	/// </summary>
	[IniSection("Box")]
	[Description("Greenshot Box Plugin configuration")]
	public interface IBoxConfiguration : IIniSection
	{
		[Description("What file type to use for uploading")]
		[DefaultValue(OutputFormats.png)]
		OutputFormats UploadFormat { get; set; }

		[Description("JPEG file save quality in %.")]
		[DefaultValue(80)]
		int UploadJpegQuality { get; set; }

		[Description("After upload send Box link to clipboard.")]
		[DefaultValue(true)]
		bool AfterUploadLinkToClipBoard { get; set; }

		[Description("Use the shared link, instead of the private, on the clipboard")]
		[DefaultValue(true)]
		bool UseSharedLink { get; set; }

		[Description("Folder ID to upload to, only change if you know what you are doing!")]
	    [DefaultValue("0")]
		string FolderId { get; set; }

		[Description("Box authorization refresh Token")]
		[TypeConverter(typeof(StringEncryptionTypeConverter))]
        string RefreshToken { get; set; }

        /// <summary>
        ///     Not stored
        /// </summary>
        [IniPropertyBehavior(Read = false, Write = false)]
        string AccessToken { get; set; }

        /// <summary>
        ///     Not stored
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [IniPropertyBehavior(Read = false, Write = false)]
        DateTimeOffset AccessTokenExpires { get; set; }
	}
}