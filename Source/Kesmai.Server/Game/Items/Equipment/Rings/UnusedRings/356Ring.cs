﻿using System.Collections.Generic;
using System.IO;
using Kesmai.Server.Game;
using Kesmai.Server.Network;
using Kesmai.Server.Spells;

namespace Kesmai.Server.Items;

public class ThreeFiftySixRing : Ring, ITreasure
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
	/// Initializes a new instance of the <see cref="ThreeFiftySixRing"/> class.
	/// </summary>
	public ThreeFiftySixRing() : base(356)
	{
	}
		
	/// <summary>
	/// Initializes a new instance of the <see cref="ThreeFiftySixRing"/> class.
	/// </summary>
	public ThreeFiftySixRing(Serial serial) : base(serial)
	{
	}

	/// <summary>
	/// Gets the description for this instance.
	/// </summary>
	public override void GetDescription(List<LocalizationEntry> entries)
	{
		entries.Add(new LocalizationEntry(6200000, 6200327)); /* [You are looking at] [a golden ring of interwoven bands.] */

		if (Identified)
			entries.Add(new LocalizationEntry(6250041)); /* The ring contains the spell of Blind Resistance. */
	}

	/// <summary>
	/// Overridable. Called when effects from this item should be applied to <see cref="MobileEntity"/>.
	/// </summary>
	protected override void OnActivateBonus(MobileEntity entity)
	{
		base.OnActivateBonus(entity);

		if (!entity.GetStatus(typeof(BlindResistanceStatus), out var resistance))
		{
			resistance = new BlindResistanceStatus(entity)
			{
				Inscription = new SpellInscription { SpellId = 47 }
			};
			resistance.AddSource(new ItemSource(this));

			entity.AddStatus(resistance);
		}
		else
		{
			resistance.AddSource(new ItemSource(this));
		}
	}

	/// <summary>
	/// Overridable. Called when effects from this item should be removed from <see cref="MobileEntity"/>.
	/// </summary>
	protected override void OnInactivateBonus(MobileEntity entity)
	{
		base.OnInactivateBonus(entity);

		if (entity.GetStatus(typeof(BlindResistanceStatus), out var resistance))
			resistance.RemoveSource(this);
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