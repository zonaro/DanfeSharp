/*
  Copyright 2012 Stefano Chizzolini. http://www.pdfclown.org

  Contributors:
    * Stefano Chizzolini (original code developer, http://www.stefanochizzolini.it)

  This file should be part of the source code distribution of "PDF Clown library" (the
  Program): see the accompanying README files for more info.

  This Program is free software; you can redistribute it and/or modify it under the terms
  of the GNU Lesser General Public License as published by the Free Software Foundation;
  either version 3 of the License, or (at your option) any later version.

  This Program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY,
  either expressed or implied; without even the implied warranty of MERCHANTABILITY or
  FITNESS FOR A PARTICULAR PURPOSE. See the License for more details.

  You should have received a copy of the GNU Lesser General Public License along with this
  Program (see README files); if not, go to the GNU website (http://www.gnu.org/licenses/).

  Redistribution and use, with or without modification, are permitted provided that such
  redistributions retain the above copyright notice, license and disclaimer, along with
  this list of conditions.
*/

using HES.Documents;
using HES.Documents.Contents.ColorSpaces;
using HES.Documents.Interaction;
using actions = HES.Documents.Interaction.Actions;
using HES.Files;
using HES.Objects;

using System;

namespace HES.Documents.Multimedia
{
  /**
    <summary>Timespan [PDF:1.7:9.1.5].</summary>
  */
  [PDF(VersionEnum.PDF15)]
  internal sealed class Timespan
    : PdfObjectWrapper<PdfDictionary>
  {
    #region dynamic
    #region constructors
    public Timespan(
      double time
      ) : base(
        new PdfDictionary(
          new PdfName[]
          {
            PdfName.Type,
            PdfName.S
          },
          new PdfDirectObject[]
          {
            PdfName.Timespan,
            PdfName.S
          }
          )
        )
    {Time = time;}

    internal Timespan(
      PdfDirectObject baseObject
      ) : base(baseObject)
    {}
    #endregion

    #region interface
    #region public
    /**
      <summary>Gets/Sets the temporal offset (in seconds).</summary>
    */
    public double Time
    {
      get => ((IPdfNumber)BaseDataObject[PdfName.V]).DoubleValue;
      set => BaseDataObject[PdfName.V] = PdfReal.Get(value);
    }
        #endregion
        #endregion
        #endregion
    }
}