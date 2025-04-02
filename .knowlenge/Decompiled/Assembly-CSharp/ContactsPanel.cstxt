using Rust.UI;
using UnityEngine;
using UnityEngine.UI;

public class ContactsPanel : SingletonComponent<ContactsPanel>
{
	public enum SortMode
	{
		None,
		RecentlySeen
	}

	public RectTransform alliesBucket;

	public RectTransform seenBucket;

	public RectTransform enemiesBucket;

	public RectTransform contentsBucket;

	public ContactsEntry contactEntryPrefab;

	public RawImage mugshotTest;

	public RawImage fullBodyTest;

	public RustButton[] filterButtons;

	public RelationshipManager.RelationshipType selectedRelationshipType = RelationshipManager.RelationshipType.Friend;

	public RustButton lastSeenToggle;

	public Phrase sortingByLastSeenPhrase;

	public Phrase sortingByFirstSeen;

	public RustText sortText;
}
