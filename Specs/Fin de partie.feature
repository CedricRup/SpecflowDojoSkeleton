Fonctionnalité: Fin de partie

@US002
@ignore	
Scénario: La partie est gagnée si il n'y a plus d'action avant l'échéance

	Etant donné le rituel 'Crocto' avec les actions suivantes
	| Intitule            | Charge |
	| Chasser un éléphant | 1      |

	Et la date de démarrage du rituel 'Crocto' est au 17/08/2014
	Et l'échéance du rituel 'Crocto' est au 17/08/2015

		
	Et le village 'Petibonum' habité par
	| Nom   |
	| Alice |

	Et le village 'Petibonum' effectue le rituel 'Crocto'

	Etant donné le plan d'action pour le rituel 'Crocto'
	| Villageois | Action              |
	| Alice      | Chasser un éléphant |

	Quand la journée se termine
	Alors le rituel est complété
	Et la partie est gangnée

@US002
@ignore	
Scénario: La partie est perdue si il reste de la charge le jour de l'échéance

Etant donné le rituel 'Crocto' avec les actions suivantes
	| Intitule            | Charge |
	| Chasser un éléphant | 2      |

	Et la date de démarrage du rituel 'Crocto' est au 17/08/2014
	Et l'échéance du rituel 'Crocto' est au 17/08/2015

		
	Et le village 'Petibonum' habité par
	| Nom   |
	| Alice |

	Et le village 'Petibonum' effectue le rituel 'Crocto'

	Etant donné le plan d'action pour le rituel 'Crocto'
	| Villageois | Action              |
	| Alice      | Chasser un éléphant |

	Quand la journée se termine
	Alors la partie est perdue car le rituel n'est pas complété

	
