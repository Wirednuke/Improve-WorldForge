using System.IO;

using Kesmai.Server.Game;

namespace Kesmai.Server.Items;

public abstract class Currency : ItemEntity, ITreasure
{
	/// <summary>
	/// Gets or sets a value indicating whether this instance is stackable.
	/// </summary>
	public override bool Stackable => true;

	/// <summary>
	/// Gets the item category.
	/// </summary>
	public override int Category => 13;

	/// <summary>
	/// Initializes a new instance of the <see cref="Currency"/> class.
	/// </summary>
	protected Currency(int currencyID) : base(currencyID)
	{
	}
	
	/// <summary>
	/// Initializes a new instance of the <see cref="Currency"/> class.
	/// </summary>
	protected Currency(Serial serial) : base(serial)
	{
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