using System;
using System.Collections.Generic;
using System.IO;

using Kesmai.Server.Network;

namespace Kesmai.Server.Items;

public class StrongStrengthRing : StrengthRing
{
	/// <summary>
	/// Gets the price.
	/// </summary>
	public override uint BasePrice => 1500;

	/// <summary>
	/// Gets the weight.
	/// </summary>
	public override int Weight => 20;

	public override int StrengthBonus => 6;
		
	/// <summary>
	/// Initializes a new instance of the <see cref="StrongStrengthRing"/> class.
	/// </summary>
	public StrongStrengthRing() : base(53)
	{
	}
	
	/// <summary>
	/// Initializes a new instance of the <see cref="StrongStrengthRing"/> class.
	/// </summary>
	public StrongStrengthRing(Serial serial) : base(serial)
	{
	}

	/// <summary>
	/// Gets the description for this instance.
	/// </summary>
	public override void GetDescription(List<LocalizationEntry> entries)
	{
		entries.Add(new LocalizationEntry(6200000, 6200045)); /* [You are looking at] [a small gold ring with a glowing red gem.] */

		if (Identified)
			entries.Add(new LocalizationEntry(6250035)); /* The ring contains a powerful spell of Strength. */
	}

	/// <summary>
	/// Serializes this instance into binary data for persistence.
	/// </summary>
	public override void Serialize(SpanWriter writer)
	{
		base.Serialize(writer);

		writer.Write((short)1); /* version */
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