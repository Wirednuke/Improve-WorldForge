using System.Collections.Generic;
using System.IO;
using Kesmai.Server.Game;
using Kesmai.Server.Network;

namespace Kesmai.Server.Items;

public class Fan : Weapon, ITreasure
{
	/// <inheritdoc />
	public override int LabelNumber => 6000034;
		
	/// <inheritdoc />
	public override int Weight => 20;

	/// <inheritdoc />
	public override uint BasePrice => 100;

	/// <inherit />
	public override Skill Skill => Skill.Hand;

	/// <inherit />
	public override int BaseArmorBonus => 4;

	/// <inherit />
	public override int ProjectileProtection => 4;
		
	/// <inheritdoc />
	public override ShieldPenetration Penetration => ShieldPenetration.None;

	/// <inherit />
	public override int MinimumDamage => 1;
		
	/// <inherit />
	public override int MaximumDamage => 2;
		
	/// <inherit />
	public override WeaponFlags Flags => WeaponFlags.Slashing | WeaponFlags.Bashing | WeaponFlags.Neutral;

	/// <inherit />
	public override bool CanBind => true;

	/// <summary>
	/// Initializes a new instance of the <see cref="Fan"/> class.
	/// </summary>
	public Fan() : base(126)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="Fan"/> class.
	/// </summary>
	public Fan(Serial serial) : base(serial)
	{
	}

	/// <inheritdoc />
	public override void GetDescription(List<LocalizationEntry> entries)
	{
		entries.Add(new LocalizationEntry(6200000, 6200302)); /* [You are looking at] [a fan with black steel blades.] */
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