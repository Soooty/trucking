Feature: Matching

Scenario: One compatible vehicle with one job
	Given the vehicles
		| Id | Compatible job types |
		| 1  | A                    |

	And the jobs
		| Id | Type |
		| 1  | A    |

	When we match the jobs with the vehicles
	
	Then following pairs will be found
		| Job id | Vehicle id |
		| 1      | 1          |

Scenario: One non compatible vehicle with one job
	Given the vehicles
		| Id | Compatible job types |
		| 1  | B                    |

	And the jobs
		| Id | Type |
		| 1  | A    |

	When we match the jobs with the vehicles
	
	Then no pairs found

Scenario: Two compatible vehicle with one job
	Given the vehicles
		| Id | Compatible job types |
		| 1  | A                    |
		| 2  | A                    |

	And the jobs
		| Id | Type |
		| 1  | A    |

	When we match the jobs with the vehicles
	
	Then following pairs will be found
		| Job id | Vehicle id |
		| 1      | 1          |

Scenario: One compatible vehicle with two job
	Given the vehicles
		| Id | Compatible job types |
		| 1  | A                    |

	And the jobs
		| Id | Type |
		| 1  | A    |
		| 2  | A    |

	When we match the jobs with the vehicles
	
	Then following pairs will be found
		| Job id | Vehicle id |
		| 1      | 1          |
				
Scenario: Two compatible vehicle with two job
	Given the vehicles
		| Id | Compatible job types |
		| 1  | A                    |
		| 2  | B                    |

	And the jobs
		| Id | Type |
		| 1  | B    |
		| 2  | A    |

	When we match the jobs with the vehicles
	
	Then following pairs will be found
		| Job id | Vehicle id |
		| 1      | 2          |
		| 2      | 1          |

Scenario: Complicated case
	Given the vehicles
		| Id | Compatible job types |
		| 1  | A B                  |
		| 2  | A                    |

	And the jobs
		| Id | Type |
		| 1  | B    |
		| 2  | A    |

	When we match the jobs with the vehicles
	
	Then following pairs will be found
		| Job id | Vehicle id |
		| 1      | 1          |
		| 2      | 2          |

Scenario: No vehicle
	Given vehicles are empty

	And the jobs
		| Id | Type |
		| 1  | A    |

	When we match the jobs with the vehicles
	
	Then no pairs found

Scenario: No Job
	Given the vehicles
		| Id | Compatible job types |
		| 1  | A                    |

	And jobs are empty

	When we match the jobs with the vehicles
	
	Then no pairs found