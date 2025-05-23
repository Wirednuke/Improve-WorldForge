using System;
using System.Collections.Generic;
using System.IO;

using Kesmai.Server.Network;

namespace Kesmai.Server.Items;

public class StarsRobe : Robe, ITreasure
{
	/// <inheritdoc />
	public override uint BasePrice => 2400;

	/// <inheritdoc />
	public override int Weight => 1600;
		
	/// <inheritdoc />
	public override int ProtectionFromFire => 5;
		
	/// <inheritdoc />
	public override int ProtectionFromIce => 5;
		
	/// <inheritdoc />
	public override int ManaRegeneration => 1;
		
	/// <summary>
	/// Initializes a new instance of the <see cref="StarsRobe"/> class.
	/// </summary>
	public StarsRobe() : base(238)
	{
	}
	
	/// <summary>
	/// Initializes a new instance of the <see cref="StarsRobe"/> class.
	/// </summary>
	public StarsRobe(Serial serial) : base(serial)
	{
	}

	/// <inheritdoc />
	public override void GetDescription(List<LocalizationEntry> entries)
	{
		entries.Add(new LocalizationEntry(6200000, 6200186)); /* [You are looking at] [a glossy black robe with swirling stars.] */

		if (Identified)
			entries.Add(new LocalizationEntry(6250030)); /* The robe looks thick and heavy. */
	}

	/// <inheritdoc />
	public override void Serialize(SpanWriter writer)
	{
		base.Serialize(writer);

		writer.Write((short)1); /* version */
	}

	/// <inheritdoc />
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