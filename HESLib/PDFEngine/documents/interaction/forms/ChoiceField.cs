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
using HES.Documents.Interaction.Annotations;
using HES.Files;
using HES.Objects;
using HES.Util;

using System;
using System.Collections;
using System.Collections.Generic;

namespace HES.Documents.Interaction.Forms
{
  /**
    <summary>Choice field [PDF:1.6:8.6.3].</summary>
  */
  [PDF(VersionEnum.PDF12)]
  public abstract class ChoiceField
    : Field
  {
    #region dynamic
    #region constructors
    /**
      <summary>Creates a new choice field within the given document context.</summary>
    */
    protected ChoiceField(
      string name,
      Widget widget
      ) : base(PdfName.Ch, name, widget)
    {}

    protected ChoiceField(
      PdfDirectObject baseObject
      ) : base(baseObject)
    {}
    #endregion

    #region interface
    #region public
    public ChoiceItems Items
    {
      get => new ChoiceItems(BaseDataObject.Get<PdfArray>(PdfName.Opt));
      set => BaseDataObject[PdfName.Opt] = value.BaseObject;
    }

        /**
          <summary>Gets/Sets whether more than one of the field's items may be selected simultaneously.
          </summary>
        */
        public bool MultiSelect
    {
      get => (Flags & FlagsEnum.MultiSelect) == FlagsEnum.MultiSelect;
      set => Flags = EnumUtils.Mask(Flags, FlagsEnum.MultiSelect, value);
    }

        /**
          <summary>Gets/Sets whether validation action is triggered as soon as a selection is made,
          without requiring the user to exit the field.</summary>
        */
        public bool ValidatedOnChange
    {
      get => (Flags & FlagsEnum.CommitOnSelChange) == FlagsEnum.CommitOnSelChange;
      set => Flags = EnumUtils.Mask(Flags, FlagsEnum.CommitOnSelChange, value);
    }
        #endregion
        #endregion
        #endregion
    }
}