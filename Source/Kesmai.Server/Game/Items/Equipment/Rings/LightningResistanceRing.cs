using System;
using System.Collections.Generic;
using System.IO;
using Kesmai.Server.Game;
using Kesmai.Server.Network;
using Kesmai.Server.Spells;

namespace Kesmai.Server.Items;

public class LightningResistanceRing : Ring, ITreasure
{
	/// <inheritdoc />
	public override uint BasePrice => 2500;

	/// <inheritdoc />
	public override int Weight => 20;

	/// <summary>
	/// Initializes a new instance of the <see cref="LightningResistanceRing"/> class.
	/// </summary>
	public LightningResistanceRing() : base(27)
	{
	}
	
	/// <summary>
	/// Initializes a new instance of the <see cref="LightningResistanceRing"/> class.
	/// </summary>
	public LightningResistanceRing(Serial serial) : base(serial)
	{
	}

	/// <inheritdoc />
	public override void GetDescription(List<LocalizationEntry> entries)
	{
		entries.Add(new LocalizationEntry(6200000, 6200058)); /* [You are looking at] [a steel ring of a sinuous dragon biting its own tail.] */

		if (Identified)
			entries.Add(new LocalizationEntry(6250046)); /* The ring contains the spell of Lightning Resist. */
	}

	/// <summary>
	/// Overridable. Called when effects from this item should be applied to <see cref="MobileEntity"/>.
	/// </summary>
	protected override void OnActivateBonus(MobileEntity entity)
	{
		base.OnActivateBonus(entity);

		if (!entity.GetStatus(typeof(LightningResistanceStatus), out var resistStatus))
		{
			resistStatus = new LightningResistanceStatus(entity)
			{
				Inscription = new SpellInscription { SpellId = 50 }
			};
			resistStatus.AddSource(new ItemSource(this));
				
			entity.AddStatus(resistStatus);
		}
		else
		{
			resistStatus.AddSource(new ItemSource(this));
		}
	}

	/// <summary>
	/// Overridable. Called when effects from this item should be removed from <see cref="MobileEntity"/>.
	/// </summary>
	protected override void OnInactivateBonus(MobileEntity entity)
	{
		base.OnInactivateBonus(entity);

		if (entity.GetStatus(typeof(LightningResistanceStatus), out var iceStatus))
			iceStatus.RemoveSource(this);
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