using System.Collections.Generic;
using System.IO;
using Kesmai.Server.Game;
using Kesmai.Server.Network;

namespace Kesmai.Server.Items;

public class SteelDagger : Dagger
{
	/// <inheritdoc />
	public override uint BasePrice => 10;
		
	/// <inheritdoc />
	protected override int PoisonedItemId => 313;

	/// <summary>
	/// Initializes a new instance of the <see cref="SteelDagger"/> class.
	/// </summary>
	public SteelDagger() : base(101)
	{
	}
	
	/// <summary>
	/// Initializes a new instance of the <see cref="SteelDagger"/> class.
	/// </summary>
	public SteelDagger(Serial serial) : base(serial)
	{
	}
		
	/// <inheritdoc />
	public override void GetDescription(List<LocalizationEntry> entries)
	{
		entries.Add(new LocalizationEntry(6200000, 6200015)); /* [You are looking at] [a steel dagger.] */

		if (Identified)
			entries.Add(new LocalizationEntry(6250014)); /* The dagger appears quite ordinary. */
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