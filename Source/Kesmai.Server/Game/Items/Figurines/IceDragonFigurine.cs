﻿using System;
using System.Collections.Generic;
using System.IO;
using Kesmai.Server.Game;
using Kesmai.Server.Network;

namespace Kesmai.Server.Items
{
	public partial class IceDragonFigurine : ItemEntity, ITreasure
	{
		/// <inheritdoc />
		public override int Weight => 5;

		/// <summary>
		/// Gets the label number.
		/// </summary>
		public override int LabelNumber => 6000036;

		/// <summary>
		/// Initializes a new instance of the <see cref="IceDragonFigurine"/> class.
		/// </summary>
		[WorldForge]
		public IceDragonFigurine() : base(375)
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="IceDragonFigurine"/> class.
		/// </summary>
		public IceDragonFigurine(Serial serial) : base(serial)
		{
		}

		/// <inheritdoc />
		public override void GetDescription(List<LocalizationEntry> entries)
		{
			entries.Add(new LocalizationEntry(6200000, 6200319)); /* [You are looking at] [a blue figurine of a dragon in flight.] */
		}
		
		/// <summary>
		/// Serializes this instance into binary data for persistence.
		/// </summary>
		public override void Serialize(BinaryWriter writer)
		{
			base.Serialize(writer);

			writer.Write((short)1);	/* version */
		}

		/// <summary>
		/// Deserializes this instance from persisted binary data.
		/// </summary>
		public override void Deserialize(BinaryReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt16();

			switch (version)
			{
				case 1:
				{
					break;
				}
			}
		}
	}
}