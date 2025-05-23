using System.Collections.Generic;
using System.IO;
using Kesmai.Server.Accounting;
using Kesmai.Server.Engines.Commands;
using Kesmai.Server.Game;
using Kesmai.Server.Network;
using Kesmai.Server.Spells;

namespace Kesmai.Server.Items;

public class ShieldRing : Ring, ITreasure
{
	/// <summary>
	/// Gets the price.
	/// </summary>
	public override uint BasePrice => 750;
		
	/// <summary>
	/// Gets the weight.
	/// </summary>
	public override int Weight => 20;

	/// <summary>
	/// Gets or sets the shield-value provided by this ring.
	/// </summary>
	[WorldForge]
	[CommandProperty(AccessLevel.GameMaster)]
	public virtual int Shield => 3;

	public ShieldRing() : this(45)
	{
	}
		
	/// <summary>
	/// Initializes a new instance of the <see cref="ShieldRing"/> class.
	/// </summary>
	public ShieldRing(int ringId) : base(ringId)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="ShieldRing"/> class.
	/// </summary>
	public ShieldRing(Serial serial) : base(serial)
	{
	}

	/// <summary>
	/// Gets the description for this instance.
	/// </summary>
	public override void GetDescription(List<LocalizationEntry> entries)
	{
		entries.Add(new LocalizationEntry(6200000, 6200046)); /* [You are looking at] [a small iron ring with a large black stone.] */

		if (Identified)
			entries.Add(new LocalizationEntry(6250128)); /* The ring contains a medium spell of Shield. */
	}

	/// <summary>
	/// Overridable. Called when effects from this item should be applied to <see cref="MobileEntity"/>.
	/// </summary>
	protected override void OnActivateBonus(MobileEntity entity)
	{
		base.OnActivateBonus(entity);

		if (!entity.GetStatus(typeof(ShieldStatus), out var status))
		{
			status = new ShieldStatus(entity)
			{
				Inscription = new SpellInscription { SpellId = 52 }
			};
			status.AddSource(new ItemSource(this));
				
			entity.AddStatus(status);
		}
		else
		{
			status.AddSource(new ItemSource(this));
		}

		entity.Stats[EntityStat.Barrier].Add(+Shield, ModifierType.Constant);
	}

	/// <summary>
	/// Overridable. Called when effects from this item should be removed from <see cref="MobileEntity"/>.
	/// </summary>
	protected override void OnInactivateBonus(MobileEntity entity)
	{
		base.OnInactivateBonus(entity);

		if (entity.GetStatus(typeof(ShieldStatus), out var status))
			status.RemoveSource(this);
		
		entity.Stats[EntityStat.Barrier].Remove(+Shield, ModifierType.Constant);
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