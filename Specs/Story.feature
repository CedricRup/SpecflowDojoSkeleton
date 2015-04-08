Fonctionnalité: Développer une story

Scénario: Quand un développeur travaille sur une story, ca charge de travaille diminue

	Etant donné le projet 'Crocto' avec les stories suivantes
	| Intitulé             | Charge |
	| Souscrire un contrat |     2  |
	
	Soit l'équipe "A-team" est constituée de 
	| Nom   |
	| Alice |

	Et l'équipe "A-team" travaille sur le projet 'Crocto'

	Quand je commence le projet 'Crocto'
	
	Etant donné que "Alice" travaille sur "Souscrire un contrat"
	Quand la journée se termine
	Alors les stories du projet 'Crocto' sont dans l'état suivant
	| Intitulé             | Charge |
	| Souscrire un contrat |     1  |

Scénario: Une story est terminée lorsque sa charge atteint 0

	Etant donné les stories suivantes
	| Intitulé             | Charge |
	| Souscrire un contrat |     1  |
	| Déclarer un sinistre |     2  |
	Soit l'équipe "A-team" est constituée de 
	| Nom   |
	| Alice |

	Quand je commence le projet 'Crocto'
	Etant donné que "Alice" travaille sur "Souscrire un contrat"
	Quand la journée se termine
	Alors les stories du projet 'Crocto' sont dans l'état suivant
	| Intitulé             | Charge |
	| Déclarer un sinistre |     2  |


	   