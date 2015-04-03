Fonctionnalité: Fin de partie
	
Scénario: La partie est gagnée si il n'y a plus de story avant la date de release

	Soit la date du jour au 01/01/2014
	Et la date de release au 17/08/2014
	Etant donné les stories suivantes
	| Intitulé             | Charge |
	| Souscrire un contrat |     1  |
	Et l'équipe constituée de 
	| Nom   |
	| Alice |
	
	Et que la partie est commencée
	Etant donné que "Alice" travaille sur "Souscrire un contrat"
	Quand la journée se termine
	Alors la partie est gagnée


Scénario: La partie est perdue si il reste de la charge le jour de la date de release

	Soit la date du jour au 16/08/2014
	Et la date de release au 17/08/2014
	Etant donné les stories suivantes
	| Intitulé             | Charge |
	| Souscrire un contrat |     2  |
	Et l'équipe constituée de 
	| Nom   |
	| Alice |
	
	Et que la partie est commencée
	Etant donné que "Alice" travaille sur "Souscrire un contrat"
	Quand la journée se termine
	Alors la partie est perdue
