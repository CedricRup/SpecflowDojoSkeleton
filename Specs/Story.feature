Fonctionnalité: Développer une story

Scénario: Quand un développeur travaille sur une story, ca charge de travaille diminue

	Etant donné les stories suivantes
	| Intitulé             | Charge |
	| Souscrire un contrat |     2  |
	Et l'équipe constituée de 
	| Nom   |
	| Alice |
	Et que la partie est commencée
	Etant donné que "Alice" travaille sur "Souscrire un contrat"
	Quand la journée se termine
	Alors les stories sont dans l'état suivant
	| Intitulé             | Charge |
	| Souscrire un contrat |     2  |

Scénario: Une story est terminée lorsque sa charge atteint 0

	Etant donné les stories suivantes
	| Intitulé             | Charge |
	| Souscrire un contrat |     1  |
	| Déclarer un sinistre |     2  |
	Et l'équipe constituée de 
	| Nom   |
	| Alice |
	Et que la partie est commencée
	Etant donné que "Alice" travaille sur "Souscrire un contrat"
	Quand la journée se termine
	Alors les stories sont dans l'état suivant
	| Intitulé             | Charge |
	| Souscrire un contrat |     2  |


	   