namespace Healths
{
    using UnityEngine;

    public abstract class Health : MonoBehaviour
    {
        [SerializeField] protected int currentHealth, maxHealth;
        [SerializeField] protected int protectionModifier;

        public virtual void TakeDamage(int amount)
        {
            if (amount == 0)
            {
                Debug.LogError($"Trying to pass a zero into damage function", this);
                return;
            }

            if (amount < 0)
            {
                Debug.LogError($"Trying to pass a negative value into damage function", this);
                return;
            }

            currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);

            if (currentHealth == 0)
            {
                Die();
            }
        }

        public virtual void Heal(int amount)
        {
            if (amount == 0)
            {
                Debug.LogError($"Trying to pass a zero into heal function", this);
                return;
            }

            if (amount < 0)
            {
                Debug.LogError($"Trying to pass a negative value into heal function", this);
                return;
            }

            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        }

        public virtual void Die() => Destroy(gameObject);
    }
}