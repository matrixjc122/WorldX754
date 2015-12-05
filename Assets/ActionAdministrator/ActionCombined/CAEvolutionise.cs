//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using RuleAdministration.Interfaces;
using UnityEngine;
using System.Collections.Generic;
using RuleAdministration.Administrators;
using System.Collections;
	
namespace RuleAdministration.Rules
{
	public class CAEvolutionise : IAction
	{
		private SAUpgrade m_upgrade;
		private SADowngrade m_downgrade;
		private int m_update_state = 0;	
		
		
		
		public override bool IsApplicable ()
		{
			{// Preprocessing
				m_upgrade = new SAUpgrade();
				m_upgrade.Tile = Tile;
				m_downgrade = new SADowngrade();
				m_downgrade.Tile = Tile;
			}
			
			
			
			if(Tile.Pal.Base().Health > 90)
			{
				m_update_state = 1;
				return m_upgrade.IsApplicable();
			}else if(Tile.Pal.Base().Health < 0.0)
			{
				m_update_state = -1;
				return m_downgrade.IsApplicable();
			}else{
				m_update_state = 0;
				return true;
			}
			
		}
			
		public override  string Name ()
		{
			return "Evolutionise";
		}
			
		public override void Update ()
		{
			
			switch(m_update_state)
			{
			case 1: ActionAdministrator.Instance.ApplyAction(m_upgrade, Tile); 
			break;
			case -1: ActionAdministrator.Instance.ApplyAction(m_downgrade, Tile); 
			break;	
			}
			
		}
		
	}
}
