/*
  Copyright 2008-2012 Stefano Chizzolini. http://www.pdfclown.org

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

using HES.Bytes;
using HES.Documents;
using HES.Objects;

using System;
using System.Drawing;

namespace HES.Documents.Interaction.Annotations
{
  /**
    <summary>Pop-up annotation [PDF:1.6:8.4.5].</summary>
    <remarks>It displays text in a pop-up window for entry and editing.
    It typically does not appear alone but is associated with a markup annotation,
    its parent annotation, and is used for editing the parent's text.</remarks>
  */
  [PDF(VersionEnum.PDF13)]
  public sealed class Popup
    : Annotation
  {
    #region dynamic
    #region constructors
    public Popup(
      Page page,
      RectangleF box,
      string text
      ) : base(page, PdfName.Popup, box, text)
    {}

    internal Popup(
      PdfDirectObject baseObject
      ) : base(baseObject)
    {}
    #endregion

    #region interface
    #region public
    /**
      <summary>Gets/Sets whether the annotation should initially be displayed open.</summary>
    */
    public bool IsOpen
        {
            get
            {
                PdfBoolean openObject = (PdfBoolean)BaseDataObject[PdfName.Open];
                return openObject != null
                  ? openObject.BooleanValue
                  : false;
            }
            set => BaseDataObject[PdfName.Open] = PdfBoolean.Get(value);
        }

        /**
          <summary>Gets/Sets the parent annotation.</summary>
        */
        public Annotation Parent
    {
      get => Annotation.Wrap(BaseDataObject[PdfName.Parent]);
      set => BaseDataObject[PdfName.Parent] = value.BaseObject;
    }
        #endregion
        #endregion
        #endregion
    }
}