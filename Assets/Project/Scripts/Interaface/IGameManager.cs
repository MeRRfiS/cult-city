using System;

namespace CultCity.Scripts.Interfaces
{
	public interface IGameManager
	{
		public event Action OnStorageOpen;
		public event Action OnStorageClose;
		public void OpenStorage();
		public void CloseStorage();
	} 
}
