﻿using System;
using System.Collections.Generic;
using System.IO;
using Kesmai.Server.Game;
using Kesmai.Server.Network;

namespace Kesmai.Server.Items;

public class ToriiBook : ItemEntity, ITreasure
{
	/// <inheritdoc />
	public override int Weight => 5;

	/// <summary>
	/// Gets the label number.
	/// </summary>
	public override int LabelNumber => 6000011;

	/// <summary>
	/// Initializes a new instance of the <see cref="ToriiBook"/> class.
	/// </summary>
	[WorldForge]
	public ToriiBook() : base(297)
	{
	}
		
	/// <summary>
	/// Initializes a new instance of the <see cref="ToriiBook"/> class.
	/// </summary>
	public ToriiBook(Serial serial) : base(serial)
	{
	}

	/// <inheritdoc />
	public override void GetDescription(List<LocalizationEntry> entries)
	{
		entries.Add(new LocalizationEntry(6200000, 6200313)); /* [You are looking at] [a book describing a mysterious land called "Torii".] */
	}
		
	/// <summary>
	/// Serializes this instance into binary data for persistence.
	/// </summary>
	public override void Serialize(SpanWriter writer)
	{
		base.Serialize(writer);

		writer.Write((short)1);	/* version */
	}

	/// <summary>
	/// Deserializes this instance from persisted binary data.
	/// </summary>
	public override void Deserialize(ref SpanReader reader)
	{
		base.Deserialize(ref reader);
			
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