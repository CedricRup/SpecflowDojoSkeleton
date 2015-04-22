Fonctionnalité: Développer une story

Scénario: Quand un développeur travaille sur une story, la charge de travail restante sur la story diminue

	Etant donné le projet 'Crocto' avec les stories suivantes
	| Titre                | Charge |
	| Souscrire un contrat | 2      |
	
	Soit l'équipe 'A-team' est constituée de 
	| Nom   |
	| Alice |

	Et l'équipe 'A-team' travaille sur le projet 'Crocto'

	Etant donné le daily pour le projet 'Crocto'
	Etant donné que 'Alice' travaille sur 'Souscrire un contrat'
	Quand la journée se termine
	Alors les stories du projet 'Crocto' sont dans l'état suivant
	| Titre                | Charge |
	| Souscrire un contrat | 1      |

Scénario: Une story est terminée lorsque sa charge atteint 0

	Etant donné le projet 'Crocto' avec les stories suivantes
	| Titre                | Charge |
	| Souscrire un contrat | 1      |
	| Déclarer un sinistre | 2      |
	Soit l'équipe 'A-team' est constituée de 
	| Nom   |
	| Alice |

	Etant donné le daily pour le projet 'Crocto'
	
	Etant donné que 'Alice' travaille sur 'Souscrire un contrat'
	Quand la journée se termine
	Alors les stories du projet 'Crocto' sont dans l'état suivant
	| Titre                | Charge |
	| Déclarer un sinistre | 2      |


	   