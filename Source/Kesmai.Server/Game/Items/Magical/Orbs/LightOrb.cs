using System.Collections.Generic;
using System.IO;
using Kesmai.Server.Game;
using Kesmai.Server.Network;
using Kesmai.Server.Spells;

namespace Kesmai.Server.Items;

public class LightOrb : SpellOrb, ITreasure
{
	/// <inheritdoc />
	public override uint BasePrice => 800;
		
	/// <summary>
	/// Initializes a new instance of the <see cref="LightOrb"/> class.
	/// </summary>
	public LightOrb() : base(201)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="LightOrb"/> class.
	/// </summary>
	public LightOrb(Serial serial) : base(serial)
	{
	}
	
	/// <inheritdoc />
	public override void GetDescription(List<LocalizationEntry> entries)
	{
		entries.Add(new LocalizationEntry(6200000, 6200277)); /* [You are looking at] [a white glass ball.] */

		if (Identified)
			entries.Add(new LocalizationEntry(6250124)); /* The ball contains the spell of light. */
	}

	/// <inheritdoc />
	protected override void PlaceEffect(MobileEntity source, Point2D location)
	{
		var spell = new LightSpell
		{
			Item = this,
				
			Intensity = 2,
			SkillLevel = 12,
				
			Cost = 0,
		};

		spell.Warm(source);
		spell.CastAt(location);
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