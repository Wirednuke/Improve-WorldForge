﻿using System.Collections.Generic;
using System.IO;
using Kesmai.Server.Game;
using Kesmai.Server.Network;
using Kesmai.Server.Spells;

namespace Kesmai.Server.Items;

public partial class ThreeFiftyFourRing : Ring, ITreasure
{
	/// <summary>
	/// Gets the price.
	/// </summary>
	public override uint BasePrice => 600;

	/// <summary>
	/// Gets the weight.
	/// </summary>
	public override int Weight => 20;

	/// <summary>
	/// Initializes a new instance of the <see cref="ThreeFiftyFourRing"/> class.
	/// </summary>
	public ThreeFiftyFourRing() : base(354)
	{
	}
		
	/// <summary>
	/// Initializes a new instance of the <see cref="ThreeFiftyFourRing"/> class.
	/// </summary>
	public ThreeFiftyFourRing(Serial serial) : base(serial)
	{
	}

	/// <summary>
	/// Gets the description for this instance.
	/// </summary>
	public override void GetDescription(List<LocalizationEntry> entries)
	{
		entries.Add(new LocalizationEntry(6200000, 6200325)); /* [You are looking at] [a platinum ring with a golden pearl set in it.] */

		if (Identified)
			entries.Add(new LocalizationEntry(6250041)); /* The ring contains the spell of Blind Resistance. */
	}

	protected override bool OnEquip(MobileEntity entity)
	{
		if (!base.OnEquip(entity))
			return false;

		if (!entity.GetStatus(typeof(BlindResistanceStatus), out var resistance))
		{
			resistance = new BlindResistanceStatus(entity)
			{
				Inscription = new SpellInscription() { SpellId = 47 }
			};
			resistance.AddSource(new ItemSource(this));

			entity.AddStatus(resistance);
		}
		else
		{
			resistance.AddSource(new ItemSource(this));
		}

		return true;
	}

	protected override bool OnUnequip(MobileEntity entity)
	{
		if (!base.OnUnequip(entity))
			return false;

		if (entity.GetStatus(typeof(BlindResistanceStatus), out var resistance))
			resistance.RemoveSource(this);

		return true;
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